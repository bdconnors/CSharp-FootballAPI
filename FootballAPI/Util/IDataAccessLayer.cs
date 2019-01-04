namespace FootballAPI.Util
{
    interface IDataAccessLayer<T>
    {
        T obj { get; set; }
        void Fetch();
        int Post();
        int Put();
        int Delete();
    }
}
