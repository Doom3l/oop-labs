using System;
using System.Collections.Generic;
using System.Drawing;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }
        public List<IMappable> Creatures { get; }
        public List<Point> Positions { get; }
        public string Moves { get; }
        public bool Finished = false;

        public string LastMessage { get; private set; } = "";

        private int moveIndex = 0;

        public IMappable CurrentCreature
        {
            get
            {
                if (Creatures.Count == 0) return null!;
                return Creatures[moveIndex % Creatures.Count];
            }
        }

        public string CurrentMoveName
        {
            get
            {
                if (Finished) return "";
                var parsed = DirectionParser.Parse(Moves);
                if (parsed.Length == 0) return "";
                return parsed[moveIndex % parsed.Length].ToString().ToLower();
            }
        }

        public Simulation(
            Map map,
            List<IMappable> creatures,
            List<Point> positions,
            string moves)
        {
            if (creatures == null || creatures.Count == 0)
                throw new ArgumentException("Creatures list is empty.");

            if (positions == null || creatures.Count != positions.Count)
                throw new ArgumentException("Creatures count must match positions count.");

            Map = map ?? throw new ArgumentNullException(nameof(map));
            Creatures = creatures;
            Positions = positions;

            var parsedMoves = DirectionParser.Parse(moves);
            if (parsedMoves.Length == 0)
                throw new ArgumentException("Moves string contains no valid directions.");

            Moves = moves;
        }

        public void Turn()
        {
            if (Finished)
                throw new InvalidOperationException("Simulation is already finished.");

            LastMessage = "";


            var parsedMoves = DirectionParser.Parse(Moves);

            if (parsedMoves.Length == 0)
            {
                Finished = true;
                return;
            }

            int creatureIndex = moveIndex % Creatures.Count;

            var creature = Creatures[creatureIndex];
            var currentPosition = Positions[creatureIndex];

            Direction direction = parsedMoves[moveIndex % parsedMoves.Length];

            Point newPos;

            if (creature is Birds b && !b.CanFly)
            {
                newPos = Map.NextDiagonal(currentPosition, direction);
            }
            else if (creature is Birds)
            {
                // ptaki latające → 2 pola
                newPos = Map.Next(
                    Map.Next(currentPosition, direction),
                    direction
                );
            }
            else
            {
                newPos = Map.Next(currentPosition, direction);
            }


            //blokowanie ruchu
            if (!Map.IsBlocked(newPos))
            {
                Positions[creatureIndex] = newPos;
            }
            else
            {
                LastMessage = "Ruch zablokowany przez przeszkodę";
            }

            creature.Go(direction);

            moveIndex++;

            if (moveIndex >= parsedMoves.Length)
                Finished = true;

            var fightersOnField = new List<IFightable>();

            for (int i = 0; i < Positions.Count; i++)
            {
                if (Positions[i].Equals(newPos) && Creatures[i] is IFightable f)
                {
                    fightersOnField.Add(f);
                }
            }

            if (fightersOnField.Count >= 2)
            {
                var attacker = fightersOnField[0];
                var defender = fightersOnField[1];

                defender.TakeDamage(1);

                if (!defender.IsAlive)
                {
                    int index = Creatures.FindIndex(c => ReferenceEquals(c, defender));

                    Map.Remove(Creatures[index], newPos);
                    Creatures.RemoveAt(index);
                    Positions.RemoveAt(index);
                }
            }


        }
    }
}
