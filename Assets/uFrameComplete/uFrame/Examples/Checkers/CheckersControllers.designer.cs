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


public abstract class CheckerBoardControllerBase : Controller {
    
    [Inject] public CheckerController CheckerController {get;set;}
    [Inject] public CheckerPlateController CheckerPlateController {get;set;}
    [Inject] public CheckersGameController CheckersGameController {get;set;}
    public virtual CheckerBoardViewModel CheckerBoard {
        get {
            return Container.Resolve<CheckerBoardViewModel>();
        }
    }
    
    public abstract void InitializeCheckerBoard(CheckerBoardViewModel checkerBoard);

    protected override ViewModel CreateEmpty() {
        return new CheckerBoardViewModel();
    }
    
    public virtual CheckerBoardViewModel CreateCheckerBoard() {
        return ((CheckerBoardViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeCheckerBoard(((CheckerBoardViewModel)(viewModel)));
    }
}

public abstract class CheckerMoveControllerBase : Controller {
    
    [Inject] public CheckersGameController CheckersGameController {get;set;}
    public abstract void InitializeCheckerMove(CheckerMoveViewModel checkerMove);
    
    protected override ViewModel CreateEmpty() {
        return new CheckerMoveViewModel();
    }
    
    public virtual CheckerMoveViewModel CreateCheckerMove() {
        return ((CheckerMoveViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeCheckerMove(((CheckerMoveViewModel)(viewModel)));
    }
}

public abstract class CheckerPlateControllerBase : Controller {
    
    [Inject] public CheckerBoardController CheckerBoardController {get;set;}
    public abstract void InitializeCheckerPlate(CheckerPlateViewModel checkerPlate);
    
    protected override ViewModel CreateEmpty() {
        return new CheckerPlateViewModel();
    }
    
    public virtual CheckerPlateViewModel CreateCheckerPlate() {
        return ((CheckerPlateViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeCheckerPlate(((CheckerPlateViewModel)(viewModel)));
    }
    
    public virtual void SelectCommand(CheckerPlateViewModel checkerPlate) {
    }
}

public abstract class CheckersGameControllerBase : Controller {
    
    [Inject] public CheckerBoardController CheckerBoardController {get;set;}
    [Inject] public CheckerController CheckerController {get;set;}
    [Inject] public CheckerMoveController CheckerMoveController {get;set;}
    public virtual CheckersGameViewModel CheckersGame {
        get {
            return Container.Resolve<CheckersGameViewModel>();
        }
    }
    
    public abstract void InitializeCheckersGame(CheckersGameViewModel checkersGame);

    protected override ViewModel CreateEmpty() {
        return new CheckersGameViewModel();
    }
    public virtual CheckersGameViewModel CreateCheckersGame() {
        return ((CheckersGameViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeCheckersGame(((CheckersGameViewModel)(viewModel)));
    }
    
    public virtual void GameOver() {
        this.GameEvent("GameOver");
    }
}

public abstract class CheckerControllerBase : Controller {
    
    [Inject] public CheckerBoardController CheckerBoardController {get;set;}
    [Inject] public CheckersGameController CheckersGameController {get;set;}
    public abstract void InitializeChecker(CheckerViewModel checker);
    
    protected override ViewModel CreateEmpty() {
        return new CheckerViewModel();
    }
    
    public virtual CheckerViewModel CreateChecker() {
        return ((CheckerViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeChecker(((CheckerViewModel)(viewModel)));
    }
    
    public virtual void SelectCommand(CheckerViewModel checker) {
    }
}

public abstract class AICheckersGameControllerBase : CheckersGameController {
    
    public virtual AICheckersGameViewModel AICheckersGame {
        get {
            return Container.Resolve<AICheckersGameViewModel>();
        }
    }
    
    public abstract void InitializeAICheckersGame(AICheckersGameViewModel aICheckersGame);
    

    protected override ViewModel CreateEmpty() {
        return new AICheckersGameViewModel();
    }
    
    public virtual AICheckersGameViewModel CreateAICheckersGame() {
        return ((AICheckersGameViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        base.Initialize(viewModel);
        this.InitializeAICheckersGame(((AICheckersGameViewModel)(viewModel)));
    }
}

public abstract class MainMenuControllerBase : Controller {
    
    public virtual MainMenuViewModel MainMenu {
        get {
            return Container.Resolve<MainMenuViewModel>();
        }
    }
    
    public abstract void InitializeMainMenu(MainMenuViewModel mainMenu);
    

    protected override ViewModel CreateEmpty() {
        return new MainMenuViewModel();
    }
    
    public virtual MainMenuViewModel CreateMainMenu() {
        return ((MainMenuViewModel)(this.Create()));
    }
    
    public override void Initialize(ViewModel viewModel) {
        this.InitializeMainMenu(((MainMenuViewModel)(viewModel)));
    }
    
    public virtual void Play() {
        this.GameEvent("Play");
    }
}

[System.SerializableAttribute()]
public sealed partial class CheckersMenuSceneManagerSettings {
    
    public string[] _Scenes;
}

public class CheckersMenuSceneManagerBase : SceneManager {
    
    public CheckersSceneManagerSettings _PlayTransition = new CheckersSceneManagerSettings();
    
    public CheckersMenuSceneManagerSettings _CheckersMenuSceneManagerSettings = new CheckersMenuSceneManagerSettings();
    
    public MainMenuController MainMenuController { get; set; }
    public override void Setup() {
        base.Setup();
        this.MainMenuController = new MainMenuController();
        this.Container.RegisterInstance(this.MainMenuController, false);
        this.Container.InjectAll();
        Container.RegisterInstance<MainMenuViewModel>(SetupViewModel<MainMenuViewModel>(MainMenuController, "MainMenu"));
    }
    
    public virtual void Play() {
        GameManager.SwitchGameAndLevel<CheckersSceneManager>((container) =>{container._CheckersSceneManagerSettings = _PlayTransition; }, this._PlayTransition._Scenes);
    }
}

public enum CheckersSceneManagerCheckersGameTypes {
    
    CheckersGame,
    
    AICheckersGame,
}

[System.SerializableAttribute()]
public sealed partial class CheckersSceneManagerSettings {
    
    public string[] _Scenes;
    
    public CheckersSceneManagerCheckersGameTypes CheckersGameTypes;
}

public class CheckersSceneManagerBase : SceneManager {
    
    public CheckersMenuSceneManagerSettings _GameOverTransition = new CheckersMenuSceneManagerSettings();
    
    public CheckersSceneManagerSettings _CheckersSceneManagerSettings = new CheckersSceneManagerSettings();
    
    public AICheckersGameController AICheckersGameController { get; set; }
    public CheckerBoardController CheckerBoardController { get; set; }
    public CheckerMoveController CheckerMoveController { get; set; }
    public CheckerPlateController CheckerPlateController { get; set; }
    public CheckersGameController CheckersGameController { get; set; }
    public CheckerController CheckerController { get; set; }
    public override void Setup() {
        base.Setup();
        this.AICheckersGameController = new AICheckersGameController();
        this.Container.RegisterInstance(this.AICheckersGameController, false);
        this.CheckerBoardController = new CheckerBoardController();
        this.Container.RegisterInstance(this.CheckerBoardController, false);
        this.CheckerMoveController = new CheckerMoveController();
        this.Container.RegisterInstance(this.CheckerMoveController, false);
        this.CheckerPlateController = new CheckerPlateController();
        this.Container.RegisterInstance(this.CheckerPlateController, false);
        this.CheckersGameController = new CheckersGameController();
        this.Container.RegisterInstance(this.CheckersGameController, false);
        this.CheckerController = new CheckerController();
        this.Container.RegisterInstance(this.CheckerController, false);
        this.Container.InjectAll();
        Container.RegisterInstance<CheckerBoardViewModel>(SetupViewModel<CheckerBoardViewModel>(CheckerBoardController, "CheckerBoard"));
        if ((this._CheckersSceneManagerSettings.CheckersGameTypes == CheckersSceneManagerCheckersGameTypes.AICheckersGame)) {
            AICheckersGameViewModel aICheckersGame = SetupViewModel<AICheckersGameViewModel>(AICheckersGameController,"CheckersGame");
            Container.RegisterInstance<AICheckersGameViewModel>(aICheckersGame, false);
            Container.RegisterInstance<CheckersGameViewModel>(aICheckersGame, false);
            Container.RegisterInstance<CheckersGameController>(AICheckersGameController, false);
        }
        if ((this._CheckersSceneManagerSettings.CheckersGameTypes == CheckersSceneManagerCheckersGameTypes.CheckersGame)) {
            CheckersGameViewModel checkersGame = SetupViewModel<CheckersGameViewModel>(CheckersGameController,"CheckersGame");
            Container.RegisterInstance<CheckersGameViewModel>(checkersGame, false);
        }
    }
    
    public virtual void GameOver() {
        GameManager.SwitchGameAndLevel<CheckersMenuSceneManager>((container) =>{container._CheckersMenuSceneManagerSettings = _GameOverTransition; }, this._GameOverTransition._Scenes);
    }
}
