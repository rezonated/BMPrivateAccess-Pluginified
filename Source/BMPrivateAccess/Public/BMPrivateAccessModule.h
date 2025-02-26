// Vanan A. / rezonated@github - 2025

#pragma once

#include "Modules/ModuleInterface.h"

class FBMPrivateAccessModule final : public IModuleInterface
{
public:
	//~ Begin IModuleInterface interface
	virtual void StartupModule() override {}
	virtual void ShutdownModule() override {}
	//~ End IModuleInterface interface
};
