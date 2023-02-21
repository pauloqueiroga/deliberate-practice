using System.Collections.Concurrent;

namespace pauloq.sports.playfetch
{
    /// <summary> 
    /// In-Memory implementation of players repository.
    /// </summary>
    internal class InMemoryRepository : IPlayerRepository
    {
        /// <summary>
        /// Name of this repository.
        /// </summary>
        public string Name { get; }

        private readonly ConcurrentDictionary<int, Player> records = new ConcurrentDictionary<int, Player>();
        private readonly ConcurrentDictionary<string, int> fullNameIndex = new ConcurrentDictionary<string, int>();
        private readonly ConcurrentDictionary<string, int> positionAgeSum = new ConcurrentDictionary<string, int>();
        private readonly ConcurrentDictionary<string, int> positionCount = new ConcurrentDictionary<string, int>();

        /// <summary>
        /// Creates an instance of InMemoryRepository with the given name.
        /// </summary>
        /// <param name="name">Name of this repository.</param>
        public InMemoryRepository(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Inserts (or updates if existing) in-memory indices and records with the given collection of players. 
        /// This will not remove any existing players if they're not present in the given collection.
        /// The full name is used as an unique identifier.
        /// </summary>
        /// <param name="players">Collection of players to update</param>
        void IPlayerRepository.InsertOrUpdate(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                var fullName = $"{player.FirstName} {player.LastName}";
                
                // If the player is new, update indices and metadata
                if (!fullNameIndex.ContainsKey(fullName)) {
                    player.ID = NewId();
                    fullNameIndex[fullName] = player.ID.Value;
                    UpdateAgeMetadata(player.Position, player.Age);
                }
                
                // Assuming that Dictionary retrieval is extremely efficient, we can retrieve the newly created index entry.
                records[fullNameIndex[fullName]] = player;
            }
        }

        private void UpdateAgeMetadata(string? position, int? age)
        {
            if (position == null)
            {
                return;
            }

            if (age == null || age == 0)
            {
                return;
            }

            var pos = position;
            var sum = 0;
            var count = 0;

            if (positionAgeSum.ContainsKey(pos))
            {
                sum = positionAgeSum[pos];
            }

            if (positionCount.ContainsKey(pos))
            {
                count = positionCount[pos];
            }

            positionAgeSum[pos] = sum + age ?? 0;
            positionCount[pos] = count + 1;
        }

        private int NewId() {
            lock(fullNameIndex)
            {
                var id = fullNameIndex.Count + 1;
                Console.WriteLine($"New record ID: {id}");
                return id;
            }
        }

        public Player? GetById(int id)
        {
            Player? result = null;

            if (records.ContainsKey(id))
            {
                result = records[id];
                var pos = result.Position ?? "unknown";
                var averageAge = positionAgeSum[pos] / positionCount[pos];
                result.AveragePositionAgeDifference = result.Age - averageAge;
            }

            return result;
        }
    }
}