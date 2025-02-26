// Vanan A. / rezonated@github - 2025

using System.IO;
using UnrealBuildTool;

public class BMPrivateAccess : ModuleRules
{
	public BMPrivateAccess(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicDependencyModuleNames.Add("Core");
		
		PublicIncludePaths.Add(Path.Combine(Path.Combine(ModuleDirectory, "ThirdParty"), "BMPrivateAccess"));
		
		CppStandard = CppStandardVersion.Latest;
	}
}
