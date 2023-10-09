namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

/// <summary>
/// This AC is needed to use labels in services without referring to the entity type, and to add new tags via inheritance.
/// I don't use interfaces because in my implementation they can only be empty. And also according to CA1040, empty interfaces
/// should not be used for tags.
/// </summary>
public class TraverseNitrinoParticleNebulae
{
    protected bool CanTraverseNitrinoParticleNebulae { get; init; }
}