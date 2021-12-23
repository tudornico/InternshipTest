namespace SantaClauseConsoleApp
{
    public class ToyReport
    {
        public Item toy { get; set; }
        public int counter { get; set; }

        public ToyReport(Item toy)
        {
            this.toy = toy;
            this.counter = 1;
        }

        public void increment()
        {
            this.counter++;
        }
    }
}