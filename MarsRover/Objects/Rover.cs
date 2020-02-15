﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{

    public enum Direction
    {
        N = 1,
        S = 2,
        E = 3,
        W = 4
    }


    public class Rover
    {
        public Plateau Plateau { get; set; }
        public Coordinate Coordinate{ get; set; }
        public Direction Direction { get; set; }


        public Rover(Plateau plateau, Coordinate coordinate, Direction direction)
        {
            this.Coordinate = coordinate;
            this.Direction = direction;
            this.Plateau = plateau;
        }

        private void Rotate(string rotateType)
        {
            if (rotateType == "L")
            {

                switch (this.Direction)
                {
                    case Direction.N:
                        this.Direction = Direction.W;
                        break;
                    case Direction.S:
                        this.Direction = Direction.E;
                        break;
                    case Direction.E:
                        this.Direction = Direction.N;
                        break;
                    case Direction.W:
                        this.Direction = Direction.S;
                        break;
                    default:
                        break;
                }
            }
            else if (rotateType == "R")
            {
                switch (this.Direction)
                {
                    case Direction.N:
                        this.Direction = Direction.E;
                        break;
                    case Direction.S:
                        this.Direction = Direction.W;
                        break;
                    case Direction.E:
                        this.Direction = Direction.S;
                        break;
                    case Direction.W:
                        this.Direction = Direction.N;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Move()
        {

            switch (this.Direction)
            {
                case Direction.N:
                    this.Coordinate.Y += 1;
                    break;
                case Direction.S:
                    this.Coordinate.Y -= 1;
                    break;
                case Direction.E:
                    this.Coordinate.X += 1;
                    break;
                case Direction.W:
                    this.Coordinate.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void StartMoving(string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.Move();
                        break;
                    case 'L':
                        this.Rotate("L");
                        break;
                    case 'R':
                        this.Rotate("R");
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                if (this.Coordinate.X < 0 || this.Coordinate.X > Plateau.Coordinate.X || this.Coordinate.Y < 0 || this.Coordinate.Y > Plateau.Coordinate.Y)
                {
                    throw new Exception($"{Plateau.Coordinate.X} , {Plateau.Coordinate.Y}");
                }
            }
        }
    }
}
