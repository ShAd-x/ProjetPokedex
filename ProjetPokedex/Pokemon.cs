using System.Text.Json;

namespace ProjetPokedex {

    public class Pokemon 
    {
        /// <summary>
        /// Déclaration de la liste qui stockera tous les <see cref="Pokemon"/>
        /// </summary>
        protected static List<Pokemon> listePokemon = new List<Pokemon>();

        /// <summary>
        /// Déclaration des listes qui stockeront les json de toutes les générations
        /// </summary>
        protected static List<string> jsonOne = new List<string>();
        protected static List<string> jsonTwo = new List<string>();
        protected static List<string> jsonThree = new List<string>();
        protected static List<string> jsonFour = new List<string>();
        protected static List<string> jsonFive = new List<string>();
        protected static List<string> jsonSix = new List<string>();
        protected static List<string> jsonSeven = new List<string>();
        protected static List<string> jsonEight = new List<string>();

        /// <summary>
        /// Déclaration des attributs qui sont nécéssaire pour les <see cref="Pokemon"/> 
        /// (par rapport à l'API)
        /// </summary>
        public int id { get; set; }
        public name name { get; set; }
        public List<string> types { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public genus genus { get; set; }
        public description description { get; set; }
        public List<stats> stats { get; set; }
        public int lastEdit { get; set; }

        /// <summary>
        /// Constructeur de la classe <see cref="Pokemon"/> avec tous les attributs
        /// </summary> 
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="types"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="genus"></param>
        /// <param name="description"></param>
        /// <param name="stats"></param>
        /// <param name="lastEdit"></param>
        public Pokemon(int id, name name, List<string> types, int height, int weight, genus genus, description description, List<stats> stats, int lastEdit)
        {
            this.id = id;
            this.name = name;
            this.types = types;
            this.height = height;
            this.weight = weight;
            this.genus = genus;
            this.description = description;
            this.stats = stats;
            this.lastEdit = lastEdit;
        }

        /// <summary>
        /// Méthode pour recupérer la <see cref="listePokemon"/> pour le compteur 
        /// de <see cref="Pokemon"/> dans la fonction principale
        /// </summary> 
        public static List<Pokemon> getListePokemon()
        {
            return listePokemon;
        }

        /// <summary>
        /// Option = 1 - Affiche tous les <see cref="Pokemon"/>
        /// </summary> 
        public static void displayAllPokemons()
        {
            Console.WriteLine("\n-----[-----------------]-----");
            foreach (Pokemon pokemon in listePokemon) // Recupérer chaque Pokémon dans la liste des Pokémons
            {
                Console.WriteLine("ID: " + pokemon.id);
                Console.WriteLine("Nom français: " + pokemon.name.fr);
            }
            Console.WriteLine("-----[-----------------]-----\n");
        }

        /// <summary>
        /// Option = 6 - Affiche un seul <see cref="Pokemon"/> par rapport à son ID 
        /// (renseigné par l'utilisateur)
        /// </summary> 
        public static void displayPokemonByID()
        {
            Console.WriteLine("Choisir un numero");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id >= 1 && id <= 898)
            {
                Pokemon pokemon = listePokemon.ElementAt(id - 1);
                Console.WriteLine("\n-----[-----------------]-----");
                Console.WriteLine(" ID: " + pokemon.id);
                Console.WriteLine(" Nom français: " + pokemon.name.fr);
                Console.Write(" Type(s): ");
                foreach (string type in pokemon.types)
                {
                    Console.Write(" " + type + " ");
                }
                Console.WriteLine("\n Hauteur: " + pokemon.height + "m");
                Console.WriteLine(" Poids: " + pokemon.weight + "kg");
                Console.WriteLine(" Genus: " + pokemon.genus.fr);
                Console.WriteLine(" Description: " + pokemon.description.fr);
                Console.WriteLine("-----[-----------------]-----\n");
            }
            else
            {
                Console.WriteLine("L'ID renseigné est incorrect (1 - 898).\n");
            }
        }

        /// <summary>
        /// Option = 5 - Retourne le poids moyen d'un type spécifique de <see cref="Pokemon"/> 
        /// (renseigné par l'utilisateur)
        /// </summary> 
        /// <param name="type"></param>
        public static void getAverageWeightByType(string type)
        {
            int totalWeight = 0;
            int numberOfPokemon = 0;

            foreach (Pokemon pokemon in listePokemon) // Recupérer chaque Pokémon dans la liste des Pokémons
            {
                if (pokemon.types.Contains(type)) // Si le pokémon possède le type 'type'
                {
                    totalWeight += pokemon.weight;
                    numberOfPokemon++;
                }
            }
            if (numberOfPokemon == 0)
            {
                Console.WriteLine("Le type renseigné est incorrect, ou aucun pokémon ne possède ce type.\n");
            }
            else
            {
                Console.WriteLine("\n-----[-----------------]-----");
                Console.WriteLine("Le poids moyen des pokémons de type " + type + " : " + totalWeight / numberOfPokemon + "kg");
                Console.WriteLine("Nombre de pokémon concerné : " + numberOfPokemon);
                Console.WriteLine("-----[-----------------]-----\n");
            }
        }

        /// <summary>
        /// Option = 3 - Retourne tous les <see cref="Pokemon"/> qui possède un type spécifique 
        /// (renseigné par l'utilisateur)
        /// </summary> 
        /// <param name="type"></param>
        public static void AllPokemonsByType(string type)
        {
            int numberOfPokemon = 0;
            Console.WriteLine("\n-----[-----------------]-----");
            foreach (Pokemon pokemon in listePokemon) // Recupérer chaque Pokémon dans la liste des Pokémons
            {
                if (pokemon.types.Contains(type)) // Si le pokémon possède le type 'type'
                {
                    Console.WriteLine("ID: " + pokemon.id);
                    Console.WriteLine("Nom français: " + pokemon.name.fr);
                    numberOfPokemon++;
                }
            }
            if (numberOfPokemon == 0)
            {
                Console.WriteLine("Aucun pokémon ne possède ce type.");
            }
            else
            {
                Console.WriteLine("\nNombre de pokémon concerné : " + numberOfPokemon);
            }
            Console.WriteLine("-----[-----------------]-----\n");
        }

        /// <summary>
        /// Option = 4 - Retourne tous les <see cref="Pokemon"/> de la 3ème génération
        /// </summary> 
        public static void getPokemonsForThirdGen()
        {
            Console.WriteLine("\n-----[-----------------]-----");
            foreach (Pokemon pokemon in listePokemon) // Recupérer chaque Pokémon dans la liste des Pokémons
            {
                if (pokemon.id >= 252 && pokemon.id <= 386) // Index de la 3ème génération
                {
                    Console.WriteLine("ID: " + pokemon.id);
                    Console.WriteLine("Nom français: " + pokemon.name.fr);
                }
            }
            Console.WriteLine("-----[-----------------]-----\n");
        }

        /// <summary>
        /// Récupérer tous les json pour ensuite les convertir en <see cref="Pokemon"/>
        /// </summary> 
        public static void getPokemonsWithMultiThreading()
        {
            Task GenOne = Task.Factory.StartNew(() => fetchGeneration(jsonOne, 1, 151));
            Task GenTwo = Task.Factory.StartNew(() => fetchGeneration(jsonTwo, 152, 251));
            Task GenThree = Task.Factory.StartNew(() => fetchGeneration(jsonThree, 252, 386));
            Task GenFour = Task.Factory.StartNew(() => fetchGeneration(jsonFour, 387, 493));
            Task GenFive = Task.Factory.StartNew(() => fetchGeneration(jsonFive, 494, 649));
            Task GenSix = Task.Factory.StartNew(() => fetchGeneration(jsonSix, 650, 721));
            Task GenSeven = Task.Factory.StartNew(() => fetchGeneration(jsonSeven, 722, 802));
            Task GenEight = Task.Factory.StartNew(() => fetchGeneration(jsonEight, 803, 898));

            // Attendre la fin de toutes les tasks pour pouvoir continuer
            Task.WaitAll(GenOne, GenTwo, GenThree, GenFour, GenFive, GenSix, GenSeven, GenEight);

            // Convertir tous les json récupérés en Pokémon pour les ajouter dans la liste des pokémons
            convertAllJsonInPokemon();
        }

        /// <summary>
        /// Option = 2 - Affiche un pokémon par type pour chaque génération
        /// </summary> 
        /// <param name="gen"></param>
        /// <param name="genMax"></param>
        /// <param name="genMin"></param>
        public static void displayPokemonPerTypePerGen(string gen, int genMin, int genMax)
        {
            List<string> stockType = new List<string>();
            int numberOfPokemon = 0;
            Console.WriteLine("\n---[---- " + gen + " génération ----]---");

            for (int i = genMin; i <= genMax; i++)
            {
                Pokemon pokemon = listePokemon[i - 1]; // -1 car la listePokemon commence à l'index 0
                foreach (string type in pokemon.types) // Pour les types du pokémon
                {
                    if (!stockType.Contains(type)) // Si le pokémon possède le type 'type'
                    {
                        Console.WriteLine("ID: " + pokemon.id);
                        Console.WriteLine("Nom français: " + pokemon.name.fr);
                        Console.WriteLine("Type: " + type + "");
                        stockType.Add(type);
                        numberOfPokemon++;
                        break;
                    }
                }
            }
            Console.WriteLine("{0} Pokémons retournés", numberOfPokemon);
        }

        /// <summary>
        /// Trie la liste 'listepokemon' dans l'ordre des id des pokémons
        /// </summary> 
        /* protected static void sortPokemonsListByID()
        {
            listepokemon = listepokemon.OrderBy(pokemon => pokemon.id).ToList();
        } */

        /// <summary>
        /// Récupère le json du pokémon avec l'id 'i', pour le mettre dans sa liste de json
        /// Permet aussi de réduire la duplication de code
        /// </summary> 
        /// <param name="json"></param>
        /// <param name="i"></param>
        protected static void getJson(List<string> json, int i)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                json.Add(webClient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + i));
            }
        }

        /// <summary>
        /// Récupérer les <see cref="Pokemon"/> de chaque génération grâce à la liste json 
        /// et des bornes de la génération
        /// </summary> 
        /// <param name="json"></param>
        /// <param name="genMin"></param>
        /// <param name="genMax"></param>
        protected static void fetchGeneration(List<string> json, int genMin, int genMax)
        {
            for (int i = genMin; i <= genMax; i++)
            {
                getJson(json, i);
            }
        }

        /// <summary>
        /// Convertir tous les json récupérés en <see cref="Pokemon"/> pour les ajouter dans la <see cref="listePokemon"/>
        /// </summary>
        protected static void convertAllJsonInPokemon()
        {
            addJsonInPokemonList(jsonOne);
            addJsonInPokemonList(jsonTwo);
            addJsonInPokemonList(jsonThree);
            addJsonInPokemonList(jsonFour);
            addJsonInPokemonList(jsonFive);
            addJsonInPokemonList(jsonSix);
            addJsonInPokemonList(jsonSeven);
            addJsonInPokemonList(jsonEight);
        }

        /// <summary>
        /// Ajoute les pokémons dans la liste de pokémon <see cref="listePokemon"/>
        /// </summary>
        /// <param name="jsonGen"></param>
        protected static void addJsonInPokemonList(List<string> jsonGen)
        {
            foreach (string json in jsonGen)
            {
                listePokemon.Add(JsonSerializer.Deserialize<Pokemon>(json));
            }
        }
    }

    public class name
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class genus
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class description
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class stats
    {
        public string name { get; set; }
        public int stat { get; set; }
    }
}