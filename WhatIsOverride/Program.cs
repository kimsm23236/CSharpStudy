namespace WhatIsOverride
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent();
            Child child = new Child();
            parent.Say();
            parent.Run();
            parent.Walk();
            child.Say();
            child.Run();
            child.Walk();

            Button button = new Button();
            StoreButton sButton = new StoreButton();
            QuestButton qButton = new QuestButton();
            button.OnClickButton();
            sButton.OnClickButton();
            qButton.OnClickButton();

            child.PressButton(sButton);
            child.PressButton(qButton);

        }
    }
}