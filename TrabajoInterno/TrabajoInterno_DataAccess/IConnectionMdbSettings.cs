namespace TrabajoInterno_DataAccess
{
    public interface IConnectionMdbSettings
    {
         string Server { get; set; }
         string DataBase { get; set; }
         string Collection { get; set; }

    }
}
