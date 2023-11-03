using Itmo.ObjectOrientedProgramming.Lab3.MessageImportanceLevel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public record Message(string Title, string Body, IImportanceLevel ImportanceLevel);