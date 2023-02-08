using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UserSearch.Models;

namespace UserSearch.Services
{
    public class UserRepository : IRepository<User, int>
    {
        private readonly ISerializationService _serialzationService;
        private readonly ConcurrentDictionary<int, User> _users = new();

        public UserRepository(ISerializationService serialzationService)
        {
            _serialzationService = serialzationService;
            if (!File.Exists("Users.xml"))
            {
                throw new FileNotFoundException("The file for Users.xml was not found at: ", Directory.GetCurrentDirectory() + "Users.xml");
            }
            var users = _serialzationService.ImportFromFile<Users>("Users.xml");
            foreach (var user in users.Context)
            {
                _users[user.Id] = user;
            }
        }

        public void Delete(int id)
        {
            if (_users.ContainsKey(id))
            {
                _ = _users.TryRemove(id, out _);
            }
        }

        public IEnumerable<User> GetAll() => _users.Values;

        public User GetByID(int id) => _users[id];

        public void Insert(User entity) => _users[entity.Id] = entity;

        public void Save()
        {
            var asList = _users.Values.ToList();
            Users users = new()
            {
                Context = asList
            };
            _serialzationService.ExportToFile<Users>(users, "Users.xml");
        }

        public bool TryDelete(int id, out User entity)
        {
            if (_users.TryRemove(id, out var user))
            {
                entity = user;
                return true;
            }
            entity = null!;
            return false;
        }

        public bool TryGetByID(int id, out User entity)
        {
            if (_users.TryGetValue(id, out var user))
            {
                entity = user;
                return true;
            }
            entity = null!;
            return false;
        }

        public bool TryInsert(User entity) => _users.TryAdd(entity.Id, entity);

        public bool TryUpdate(User entity)
        {
            if (_users.TryGetValue(entity.Id, out var value))
            {
                return _users.TryUpdate(entity.Id, entity, value);
            }
            return false;
        }

        public void Update(User entity) => _ = _users.AddOrUpdate(entity.Id, entity, (_, __) => entity);
    }
}
