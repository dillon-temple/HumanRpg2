using System;

namespace HumanRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Billy = new Human("Billy");
            Human Jared = new Human("Jared");
            Wizard Merlin = new Wizard("Merlin");
            Wizard Dumbo = new Wizard("Dumbo");
            Ninja WeeboSan = new Ninja("WeeboSan");
            Samurai Joey = new Samurai("Joey");
            Console.WriteLine($"Jareds health is {Jared.Health}");
            Merlin.Attack(Jared);
            WeeboSan.Attack(Billy);
            Joey.Attack(Merlin);
            Joey.Attack(Dumbo);
            Merlin.Heal(WeeboSan);
            Billy.Attack(Joey);
            Joey.Meditate();
            WeeboSan.Steal(Joey);

        }
    }

    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health{
            get;set;
        }


        public Human(){
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Name = "Bobby Hill";
            Health = 100; 
        }

        public Human(string name)
        {
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Name = name;
            Health = 100;
        }

        public Human(string name, int str, int intel, int dex, int startHealth){
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Health = startHealth;
        }

        public virtual int Attack(Human target)
        {
            int damage = this.Strength * 5;
            target.Health -= damage;
            Console.WriteLine($"{target.Name} took {damage} damage and is now at {target.Health} health");
            return target.Health;
        }
    }
    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Intelligence = 25;
            Health = 50;
        }

        public override int Attack(Human target){
            int damage = this.Intelligence * 5;
            target.Health -= damage;
            this.Health += damage;
            Console.WriteLine($"{this.Name} gained {damage} health and is now at {this.Health} health");
            Console.WriteLine($"Your target took {damage} damage and is now at {target.Health} health");
            return target.Health;
        }

        public int Heal(Human target){
            int heal = this.Intelligence * 10;
            target.Health += heal;
            Console.WriteLine($"Your target healed {heal} health and is now at {target.Health} health");
            return target.Health;

        }
    }

    class Ninja : Human {

        Random random = new Random();
        public Ninja(string name) : base(name){
            Dexterity = 175;
        }

        public override int Attack(Human target){
            int damage = this.Dexterity * 5;
            int crit = random.Next(0,5);
            if(crit == 0){
                damage += 10;
            }

            target.Health -= damage;
            Console.WriteLine($"Your target took {damage} damage and is now at {target.Health} health");
            return target.Health;
        }

        public int Steal(Human target){
            target.Health -= 5;
            this.Health += 5;
            Console.WriteLine($"{this.Name} stole 5 life from {target.Name}");
            return target.Health;
        }
    }
    class Samurai : Human {
        public Samurai(string name) : base(name){
            Health = 200;
        }

        public override int Attack(Human target){
            int execute = base.Attack(target);
            if(execute <= 50){
                target.Health = 0;
                Console.WriteLine($"Your target was executed!");
                return target.Health;
            }
            Console.WriteLine($"Your target took {this.Strength * 5} damage and is now at {target.Health} health");
            return target.Health;
        }

        public int Meditate(){
            this.Health = 200;
            Console.WriteLine($"You meditate and heal back to full life! {this.Health}");
            return this.Health;
        }
    }

}
