﻿using System;

namespace sample
{
    enum Status
    {
        Euqal,
        LessThan,
        MoreThan,
        InputOutOfRange
    }

    class Game
    {
        readonly int _minValue;
        readonly int _maxValue;

        int _number;
        readonly Random _random = new Random();

        public Game(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;

            GenerateNumber();
        }

        public int GetMinValue()
        {
            return _minValue;
        }

        public int GetMaxValue()
        {
            return _maxValue;
        }

        private void GenerateNumber()
        {
            _number = _random.Next(_minValue, _maxValue);
        }

        public void NewGame()
        {
            GenerateNumber();
        }

        public bool IsInRange(int value)
        {
            if (_minValue <= value && _maxValue >= value)
                return true;
            else
                return false;
        }

        public Status Query(int value)
        {
            if (!IsInRange(value))
                return Status.InputOutOfRange;

            if (value == _number)
                return Status.Euqal;
            else if (value < _number)
                return Status.MoreThan;
            else
                return Status.LessThan;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(0, 100);

            Status status = Status.Euqal;
            do
            {
                Console.WriteLine("input the number. (" + game.GetMinValue() + " ~ " + game.GetMaxValue() + ")");

                bool isValidInput = int.TryParse(Console.ReadLine(), out int inputNum);
                if (!isValidInput)
                {
                    Console.WriteLine("input the correct number");
                    continue;
                }

                status = game.Query(inputNum);
                if (status == Status.Euqal)
                {
                    Console.WriteLine("Correct answer.");
                }
                else if (status == Status.LessThan)
                {
                    Console.WriteLine("choose more smaller number.");
                }
                else if (status == Status.MoreThan)
                {
                    Console.WriteLine("choose more bigger number.");
                }
                else if (status == Status.InputOutOfRange)
                {
                    Console.WriteLine("out of range.");
                }

            } while (status != Status.Euqal);

            Console.WriteLine("Game is over.");

            Console.ReadLine();
        }
    }
}