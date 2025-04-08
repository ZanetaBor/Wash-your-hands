
using Microsoft.Web.Services3;

namespace MyApp.Data
{
    public class GameLogic
    {
        public List<Bacteria> FullOffBacteria { get; set; }=new List<Bacteria>();

        public List<Medicine> Medicines { get; set; } = new List<Medicine>();

        public Soap soap  = new Soap();
        public Dirty dirty = new Dirty();  

        public int Width { get; set; } = 800;

        public int Height { get; set; } = 600;

        public void Update()
        {
            foreach (Bacteria bacteria in FullOffBacteria)
            {
                bacteria.Move();
            }

            foreach (Medicine medicine in Medicines)
            {
                medicine.Move();
            }

            soap.Move();
            dirty.Move();   

            DestroyItems();
        }

        private void DestroyItems()
        {
            int threshold = 5;

            foreach (var e1 in FullOffBacteria)
            {
                var match = Medicines.FirstOrDefault(e2 =>
                Math.Abs(e1.PositionX-e2.PositionX)<=threshold &&
                Math.Abs(e1.PositionY - e2.PositionY) <= threshold
                );

                if(match != null)
                {
                    e1.Health = 0;
                }

            }

            FullOffBacteria.RemoveAll(e => e.Health == 0);

            FullOffBacteria.RemoveAll(e => e.PositionY > Height);

            Medicines.RemoveAll(e => e.PositionY < 0);

        }
    }
}
