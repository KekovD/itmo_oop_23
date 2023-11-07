using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableMessagesIntegration.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Renderables.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public interface IDisplayDriver
{
    void ClearOutput();

    RenderableMessage SetTitleColor(Color color);

    RenderableMessage SetBodyColor(Color color);

    public void WriteText(Text text);

    public void DrawMessage();
}