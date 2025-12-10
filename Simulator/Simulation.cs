using System;
using System.Collections.Generic;
using System.Drawing;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }
        public List<Creature> Creatures { get; }
        public List<Point> Positions { get; }
        public string Moves { get; }
        public bool Finished = false;

        private int moveIndex = 0;

        public Creature CurrentCreature
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

        public Simulation(Map map, List<Creature> creatures,
            List<Point> positions, string moves)
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

            Point newPos = Map.Next(currentPosition, direction);

            Positions[creatureIndex] = newPos;

            creature.Go(direction);

            moveIndex++;

            if (moveIndex >= parsedMoves.Length)
                Finished = true;
        }
    }
}
