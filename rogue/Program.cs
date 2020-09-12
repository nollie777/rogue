﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogue
{
    class Program
    {
        static void Main(string[] args)
        {


        }

    }

    abstract class Tile
    {
        protected int X;

        public int x
        {
            get { return x; }
            set { x = value; }
        }

        protected int Y;

        public int y
        {
            get { return y; }
            set { y = value; }
        }

        public enum TileType { Hero, Enemy, Weapon, Gold };

        //private TileType currentTile;

        public TileType getTile
        {
            get { return getTile; }
            set { getTile = value; }
        }

        public Tile(int xPos, int yPos)
        {
            xPos = 0;
            yPos = 0;
            getTile = TileType.Hero;
        }
    }

    class Obstacle : Tile
    {

        private Obstacle(int xPos, int yPos) : base(xPos, yPos)
        {

            xPos = 0;

            yPos = 0;

        }

    }

    class emptyTile : Tile
    {
        private emptyTile(int xPos, int yPos) : base(xPos, yPos)
        {

            xPos = 0;

            yPos = 0;



        }
    }

    abstract class Character : Tile
    {

        //protected int newX;

        //protected int newY;

        private Character(int xPos, int yPos, char symbol) : base(xPos, yPos)
        {

        }

        protected int HP;

        public int getHP
        {

            get { return HP; }
            set { HP = value; }
        }

        protected int maxHP;

        public int getMaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        protected int damage;

        public int getDamage
        {
            get { return damage; }
            set { value = damage; }
        }

        protected Tile[,] vision;

        public Tile[,] getVision
        {
            get { return vision; }
            set { vision = value; }
        }

        public enum movement
        {
            none = 0,
            up = 1,
            down = 2,
            left = 3,
            right = 4

        };

        //private movement GetMovement;

        public movement GetMovement
        {
            get { return GetMovement; }
            set { value = GetMovement; }
        }

        public virtual void Attack(Character target)
        {
            HP = HP - damage;
        }

        public bool IsDead()
        {
            return false;
        }

        public virtual bool CheckRange(Character target)
        {

            if (DistanceTo(target) < 2)
            {
                return true;
            }

            else
                return false;

        }

        private int DistanceTo(Character target)
        {

            return Math.Abs((this.x - target.x) + (this.y - target.y));

        }

        public void Move(movement move)
        {

            switch (move)
            {
                case movement.down:
                    {
                        y--;
                        break;
                    }

                case movement.up:
                    {
                        y++;
                        break;
                    }

                case movement.left:
                    {
                        x--;
                        break;
                    }

                case movement.right:
                    {
                        x++;
                        break;
                    }

                case movement.none:
                    {
                        break;
                    }

            }

        }

        public abstract movement returnMove(movement move = 0);
       
        public abstract override string ToString();

    }

    }

