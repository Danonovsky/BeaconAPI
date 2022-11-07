namespace BeaconAPI.Entities;

public class Place : BaseEntity
{
    public string Name { get; set; }
    public virtual List<Beacon> Beacons { get; set; }
}
