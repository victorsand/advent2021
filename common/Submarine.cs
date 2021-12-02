using System;
using System.Linq;

namespace advent2021.common
{
    public class SubmarineCommand
    {
        public Enums.Direction Direction { get; set; }
        public int Units { get; set; }

        public override string ToString()
        {
            return $"{nameof(Direction)}: {Direction}, {nameof(Units)}: {Units}";
        }
        
        public static SubmarineCommand ParseCommand(string line)
        {
            var dirStr = line.Split(" ").First();
            var direction = dirStr switch
            {
                "forward" => Enums.Direction.Forward,
                "up" => Enums.Direction.Up,
                "down" => Enums.Direction.Down,
                _ => throw new ArgumentException()
            };
            return new SubmarineCommand
            {
                Direction = direction,
                Units = int.Parse(line.Split(" ").Last())
            };
        }
    }

    public class SubmarinePosition
    {
        public int Depth { get; set; }
        public int HorizontalPosition { get; set; }
        public int Aim { get; set; }

        public SubmarinePosition()
        {
            Depth = 0;
            HorizontalPosition = 0;
            Aim = 0;
        }

        public void ApplyCommand(SubmarineCommand command, bool useAim = false)
        {
            Console.WriteLine($"Hor {HorizontalPosition}, Depth {Depth}");
            switch (command.Direction)
            {
                case Enums.Direction.Up:
                    if (useAim) Aim -= command.Units;
                    else Depth -= command.Units;
                    return;
                case Enums.Direction.Down:
                    if (useAim) Aim += command.Units;
                    else Depth += command.Units;
                    return;
                case Enums.Direction.Forward:
                    HorizontalPosition += command.Units;
                    if (useAim) Depth += Aim * command.Units;
                    return;
            }
            
        }
    }
}