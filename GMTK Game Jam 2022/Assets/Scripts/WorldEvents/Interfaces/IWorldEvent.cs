namespace WorldEvents.Interfaces
{
    /*
     * All world events triggered by the dice rolls should
     * inherit from this interface
     */
    public interface IWorldEvent
    {
        public void Activate();
    }
}
