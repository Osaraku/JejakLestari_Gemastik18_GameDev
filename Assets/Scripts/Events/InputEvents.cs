using System;

public class InputEvents
{
    public InputEventContext inputEventContext { get; private set; } = InputEventContext.DEFAULT;

    public void ChangeInputEventContext(InputEventContext newContext)
    {
        this.inputEventContext = newContext;
    }

    public event Action<InputEventContext> onSubmitPressed;
    public void SubmitPressed()
    {
        if (onSubmitPressed != null)
        {
            onSubmitPressed(this.inputEventContext);
        }
    }

    public event Action<InputEventContext> onClickPressed;
    public void ClickPressed()
    {
        if (onClickPressed != null)
        {
            onClickPressed(this.inputEventContext);
        }
    }
}
