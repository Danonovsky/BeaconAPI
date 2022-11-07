namespace BeaconAPI.Entities;

//f) id, nazwa, gdzie zamontowany: pomieszczenie, wspolrzedne, data i czas montażu/serwisu
public class Beacon : BaseEntity
{
    public string Name { get; set; }
    public DateTime InstalledAt { get; set; }
    public DateTime LastServicedAt { get; set; }
    public Guid PlaceId { get; set; }
    public virtual Place Place { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
