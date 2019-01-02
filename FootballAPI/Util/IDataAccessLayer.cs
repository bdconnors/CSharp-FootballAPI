namespace FootballAPI.Util
{
    interface IDataAccessLayer<T>
    {
        void Fetch(T obj);
        int Post(T obj);
        int Put(T obj);
        int Delete(T obj);
    }
}
