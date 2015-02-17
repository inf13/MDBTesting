namespace MDB.Infrastructure.Operations
{
    public interface IUserOperation : IEntityOperation
    {
        void SetRating(float rating);
    }
}