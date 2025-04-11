
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
                // is my obstacle should still exist? If not - remove item
                if (entity is Obstacle o && !o.IsExist)
                    Entities.Remove(entity);

                // remove obstacle from js
                //if (entity is Soap soap && !soap.IsExist)
                //{
                //    JSRuntime.InvokeVoidAsync("clearSoap"); 
                //}
            }
            DestroyItems();

        }

        private void DestroyItems()
        {
            int threshold = 5;

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

            // znikniecie bakterii/lekow po przekroczeniu wysokosci
            Entities.RemoveAll(e =>
                (e is Bacteria b && (b.Health == 0 || b.PositionY > Height)) ||
                (e is Medicine m && m.PositionY < 0)
                );
        }
    }
}
