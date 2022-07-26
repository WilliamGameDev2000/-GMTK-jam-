namespace WorldEvents.Interfaces
{
    /*
     * Interface that all world events should inherit from
     */
    public interface IWorldEvent
    {
        public void Activate();
        public void Update();
    }
}
