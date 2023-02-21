using System.Collections.Concurrent;

namespace pauloq.sports.playfetch
{
    internal interface IPlayerRepository
    {
        string Name { get; }
        void Update(IEnumerable<Player> players);
    }

    internal class InMemoryRepository : IPlayerRepository
    {
        public string Name { get; }

        private readonly ConcurrentDictionary<int, Player> records = new ConcurrentDictionary<int, Player>();
        private readonly ConcurrentDictionary<string, int> fullNameIndex = new ConcurrentDictionary<string, int>();

        public InMemoryRepository(string name)
        {
            Name = name;
        }

        void IPlayerRepository.Update(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                var fullName = $"{player.FirstName} {player.LastName}";
                
                if (!fullNameIndex.ContainsKey(fullName)) {
                    fullNameIndex[fullName] = NewId();
                }
                
                records[fullNameIndex[fullName]] = player;
            }
        }

        private int NewId() {
            lock(fullNameIndex)
            {
                var id = fullNameIndex.Count + 1;
                Console.WriteLine($"New record ID: {id}");
                return id;
            }
        }
    }
}