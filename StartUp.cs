using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Tournament")
                {
                    break;
                }

                string[] info = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (info.Length != 4)
                {
                    Environment.Exit(1);
                }

                string trainerName = info[0];
                string pokeName = info[1];
                string pokeElement = info[2];
                int pokeHealth = int.Parse(info[3]);


                if (!trainers.Any(tr => tr.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                var currTrainer = trainers.Find(tr => tr.Name == trainerName);
                currTrainer.Pokemons.Add(new Pokemon(pokeName, pokeElement, pokeHealth)); 
            }

            while (true)
            {
                string lineElement = Console.ReadLine();

                if (lineElement == "End")
                {
                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(po => po.Element == lineElement))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }   
            }

            foreach (Trainer trainer in trainers.OrderByDescending(tr => tr.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
