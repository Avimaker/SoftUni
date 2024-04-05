namespace RobotService
{
    using RobotService.Core;
    using RobotService.Core.Contracts;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}


/*

CreateRobot K-2SO IndustrialAssistant
CreateRobot T-X IndustrialAssistant
CreateRobot AVA DomesticAssistant
CreateRobot KUSANAGI IndustrialAssistant
CreateRobot C-3PO DomesticAssistant
CreateRobot R2-D2 DomesticAssistant
CreateRobot C1-10P SocialAssistant
CreateRobot C-3PO DomesticAssistant
CreateSupplement FaceRecognitionCamera
CreateSupplement SpecializedArm
CreateSupplement SpecializedArm
CreateSupplement SpecializedArm
CreateSupplement SpecializedArm
CreateSupplement LaserRadar
CreateSupplement LaserRadar
CreateSupplement LaserRadar
CreateSupplement LaserRadar
PerformService Dishwashing 10045 1000
UpgradeRobot C-3PO SpecializedArm
UpgradeRobot C-3PO SpecializedArm
UpgradeRobot C-3PO SpecializedArm
UpgradeRobot C-3PO LaserRadar
UpgradeRobot R2-D2 SpecializedArm
UpgradeRobot KUSANAGI LaserRadar
UpgradeRobot KUSANAGI SpecializedArm
PerformService PaintRoad 20082 100000
PerformService DishWashing 10045 1000
PerformService AutomotiveAssembly 10045 25000
RobotRecovery C-3PO 3
RobotRecovery KUSANAGI 3
Report
 
 
 */