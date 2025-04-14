
using Microsoft.JSInterop;
using Microsoft.Web.Services3;
using MyApp.Data.Dto;

namespace MyApp.Data
{
    public class GameLogic
    {
        public Soap Soap { get; private set; }

        public Dirty Dirty { get; private set; }

        public int Width { get; set; } = 800;

        public int Height { get; set; } = 600;

        // Entities with all GameObject
        public List<GameObject> Entities { get; set; } = new();


        // Method dynamically creates an obstacle of type T.
        public void CreateObstacle<T>() where T : Obstacle, new()
        {
            T obstacle = new T();
            obstacle.Move();

            Entities.Add(obstacle);

            if (obstacle is Soap soap)
                Soap = soap;

            if (obstacle is Dirty dirty)
                Dirty = dirty;
        }

        public ObstacleDto ToDto(Obstacle obstacle)
        {
            return new ObstacleDto
            {
                PositionX = obstacle.PositionX,
                PositionY = obstacle.PositionY,
                Type = obstacle.GetType().Name.ToLower()
            };
        }


        public void CreateBacteria()
        {
            var bacteria = new Bacteria();
            Entities.Add(bacteria);
        }

        public void CreateMedicine()
        {
            var medicine = new Medicine();
            Entities.Add(medicine);
        }

        public void Update()
        {
            foreach (var entity in Entities.ToList())
            {
                entity.Move();
                if (entity is Obstacle o && !o.IsExist)
                    Entities.Remove(entity);
            }
            DestroyItems();
            BacteriaReplicating();
        }

        private void DestroyItems()
        {
            int threshold = 60;

            var bacteriaList = Entities.OfType<Bacteria>().ToList();
            var medicineList = Entities.OfType<Medicine>().ToList();

            foreach (var bacteria in bacteriaList)
            {
                var match = medicineList.FirstOrDefault(m =>
                    Math.Abs(bacteria.PositionX - m.PositionX) <= threshold &&
                    Math.Abs(bacteria.PositionY - m.PositionY) <= threshold
                );

                if (match != null)
                {
                    bacteria.Health = 0;
                }
            }

            if (Soap != null && Soap.IsExist)
            {
                Console.WriteLine($"Soap position: {Soap.PositionX}, {Soap.PositionY}");
                foreach (var bacteria in bacteriaList)
                {
                    Console.WriteLine($"Checking bacteria at: {bacteria.PositionX}, {bacteria.PositionY}");
                    if (Math.Abs(bacteria.PositionX - Soap.PositionX) <= threshold &&
                        Math.Abs(bacteria.PositionY - Soap.PositionY) <= threshold)
                    {
                        Console.WriteLine("Bacteria touched soap! Setting health to 0.");
                        bacteria.Health = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("Soap is null or not existing.");
            }


            // znikniecie bakterii/lekow po przekroczeniu wysokosci
            Entities.RemoveAll(e =>
                (e is Bacteria b && (b.Health == 0 || b.PositionY > Height)) ||
                (e is Medicine m && m.PositionY < 0)
                );
        }

        private void BacteriaReplicating()
        {
            int threshold = 60;

            var bacteriaList = Entities.OfType<Bacteria>().ToList();
            if (Dirty != null && Dirty.IsExist)
            {
                Console.WriteLine($"Dirty position: {Dirty.PositionX}, {Dirty.PositionY}");
                foreach (var bacteria in bacteriaList)
                {
                    Console.WriteLine($"Checking bacteria at: {bacteria.PositionX}, {bacteria.PositionY}");
                    if (Math.Abs(bacteria.PositionX - Dirty.PositionX) <= threshold &&
                        Math.Abs(bacteria.PositionY - Dirty.PositionY) <= threshold)
                    {
                        Console.WriteLine("Bacteria touched dirty! Setting health to 80.");
                        bacteria.Health = 80;
                    }
                }
            }
            else
            {
                Console.WriteLine("Dirty is null or not existing.");
            }
        }
    }
}
