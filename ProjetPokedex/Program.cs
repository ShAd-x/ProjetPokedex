namespace ProjetPokedex {

    class Program
    {
        /// <summary>
        /// Fonction principale, récupère les <see cref="Pokemon"/> en multi-threading
        /// et ouvre ensuite le menu à l'utilisateur (fonction en dessous '<see cref="getMenu"/>')
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Récupération des pokémons en cours, veuillez patienter...");
            Pokemon.getPokemonsWithMultiThreading();
            Console.WriteLine("{0} Pokémons récupérés", Pokemon.getListePokemon().Count());
            getMenu();
        }

        /// <summary>
        /// Affiche le menu à l'utilisateur
        /// </summary>
        protected static void getMenu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("Choisir une option: \n");
                Console.WriteLine("1: Afficher la liste des Pokemons (numéro et nom français)");
                Console.WriteLine("2: Afficher un Pokemon de chaque type pour chaque génération");
                Console.WriteLine("3: Afficher tous les Pokemons d'un type (au choix)");
                Console.WriteLine("4: Afficher tous les Pokemons de la génération 3");
                Console.WriteLine("5: Afficher la moyenne des poids des Pokémons par Type");
                Console.WriteLine("6: Afficher un Pokemon par son ID");
                Console.WriteLine("7: Stopper le programme \n");
          
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Pokemon.displayAllPokemons();
                            break;
                        case 2:
                            Console.Write("\n-----[-----------------]-----");
                            Pokemon.displayPokemonPerTypePerGen("Première", 1, 151);
                            Pokemon.displayPokemonPerTypePerGen("Deuxième", 152, 251);
                            Pokemon.displayPokemonPerTypePerGen("Troisième", 252, 386);
                            Pokemon.displayPokemonPerTypePerGen("Quatrième", 387, 493);
                            Pokemon.displayPokemonPerTypePerGen("Cinquième", 494, 649);
                            Pokemon.displayPokemonPerTypePerGen("Sixième", 650, 721);
                            Pokemon.displayPokemonPerTypePerGen("Septième", 722, 802);
                            Pokemon.displayPokemonPerTypePerGen("Huitième", 803, 898);
                            Console.WriteLine("-----[-----------------]-----\n");
                            break;
                        case 3:
                            Console.WriteLine("Choisir un type (Normal, Electric, Flying, Fire, Steel, ...)");
                            Pokemon.AllPokemonsByType(Console.ReadLine());
                            break;
                        case 4:
                            Pokemon.getPokemonsForThirdGen();
                            break;
                        case 5:
                            Console.WriteLine("Choisir un type (Normal, Electric, Flying, Fire, Steel, ...)");
                            Pokemon.getAverageWeightByType(Console.ReadLine());
                            break;
                        case 6:
                            Pokemon.displayPokemonByID();
                            break;
                        default:
                            break;
                    }
                } catch (Exception) { }
            } while (option != 7);
        }
    }
}