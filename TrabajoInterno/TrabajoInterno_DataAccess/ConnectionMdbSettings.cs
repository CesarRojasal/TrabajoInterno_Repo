namespace TrabajoInterno_DataAccess
{
    public class ConnectionMdbSettings: IConnectionMdbSettings
    {
        public string Server { get; set; } = string.Empty;
        public string DataBase { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;
    }
}
