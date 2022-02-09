namespace TrabajoInterno_Api_Imagen.Data
{
    public interface IConnectionMdbSettings
    {
         string Server { get; set; }
         string DataBase { get; set; }
         string Collection { get; set; }

    }
}
