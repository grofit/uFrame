// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;


public abstract class PlaymakerElementControllerBase : Controller {
    
    public abstract void InitializePlaymakerElement(PlaymakerElementViewModel playmakerElement);
    
   
    protected override ViewModel CreateEmpty() {
        return new PlaymakerElementViewModel();
    }
    
    public virtual PlaymakerElementViewModel CreatePlaymakerElement() {
        return ((PlaymakerElementViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializePlaymakerElement(((PlaymakerElementViewModel)(viewModel)));
    }
    
    public virtual void Upgrade(PlaymakerElementViewModel playmakerElement) {
    }
    
    public virtual void Kill(PlaymakerElementViewModel playmakerElement) {
    }
    
    public virtual void Tick(PlaymakerElementViewModel playmakerElement) {
    }
}

[System.SerializableAttribute()]
public sealed partial class PlaymakerExampleManagerSettings {
    
    public string[] _Scenes;
}

public class PlaymakerExampleManagerBase : SceneManager {
    
    public PlaymakerExampleManagerSettings _PlaymakerExampleManagerSettings = new PlaymakerExampleManagerSettings();
    
    public PlaymakerElementController PlaymakerElementController { get; set; }
    public override void Setup() {
        base.Setup();
        this.PlaymakerElementController = new PlaymakerElementController();
        this.Container.RegisterInstance(this.PlaymakerElementController, false);
        this.Container.InjectAll();
    }
}
