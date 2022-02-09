namespace TrabajoInterno_Api_Imagen.Data
{
    public class ConnectionMdbSettings: IConnectionMdbSettings
    {
        public string Server { get; set; } = string.Empty;
        public string DataBase { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;
    }
}
