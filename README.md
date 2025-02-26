# BMPrivateAccess-Pluginified
This is just a pluginified version of BMPrivateAccess a library to access non-public members and functions, created by [Blueman2](https://github.com/Blueman2) - [Original BMPrivateAccess repo](https://github.com/Blueman2/BMPrivateAccess)

Tested in UE 5.5 using MSVC with latest C++ standard enabled.

Technically the library supports C++17, so it can be used in UE 4.27 as well.

## Installation
- Clone the repo with submodules using ``` git clone --recursive https://github.com/rezonated/BMPrivateAccess-Pluginified.git ``` command inside your C++ project's ```Plugins/``` folder.
- Enable the ```BMPrivateAccess``` plugin by modifying the ```.uproject``` or via editor,
- In your C++ module's ```Build.cs```, add ```BMPrivateAccess``` as the dependency.

## Usage in Unreal Engine code example
```cpp
UCLASS()
class UBMPrivateAccessTest : public UObject
{
    GENERATED_BODY()
public:
    UBMPrivateAccessTest()
    {
        bIsTodayFriday = FMath::RandBool();
        RandomNumber = GenerateRandomNumber();
        ArrayOfGuids.Reserve(25);
    }

private:
    UPROPERTY(Transient)
    bool bIsTodayFriday = false;

    int32 RandomNumber = 0;

    static int32 GenerateRandomNumber() { return FMath::Rand32(); }

    UPROPERTY(Transient)
    TArray<FGuid> ArrayOfGuids;

    UFUNCTION()
    void SetTodayFriday(bool bInIsTodayFriday) { bIsTodayFriday = bInIsTodayFriday; }
};

DEFINE_PRIVATE_MEMBER_ACCESSOR(UBMPrivateAccessTest, bIsTodayFriday, bool);
DEFINE_PRIVATE_MEMBER_ACCESSOR(UBMPrivateAccessTest, RandomNumber, int32);
DEFINE_PRIVATE_MEMBER_ACCESSOR(UBMPrivateAccessTest, ArrayOfGuids, TArray<FGuid>);

DEFINE_PRIVATE_FUNCTION_ACCESSOR(UBMPrivateAccessTest, GenerateRandomNumber, int32);
DEFINE_PRIVATE_FUNCTION_ACCESSOR(UBMPrivateAccessTest, SetTodayFriday, void);

UCLASS(BlueprintType)
class ABMPrivateAccessTestActor : public AActor
{
    GENERATED_BODY()

protected:
    virtual void BeginPlay() override
    {
        Super::BeginPlay();
    
        UBMPrivateAccessTest* Test = NewObject<UBMPrivateAccessTest>();
        const bool* bIsTodayFriday = &UBMPrivateAccessTest_Private::Get_bIsTodayFriday(*Test);
    
        int32* RandomNumber = &UBMPrivateAccessTest_Private::Get_RandomNumber(*Test);
        *RandomNumber = UBMPrivateAccessTest_Private::Call_GenerateRandomNumber();
        
        UBMPrivateAccessTest_Private::Call_SetTodayFriday(*Test, !*bIsTodayFriday);
    
        TArray<FGuid>* RandomNumbers = &UBMPrivateAccessTest_Private::Get_ArrayOfGuids(*Test);
        for (int i = 0; i < RandomNumbers->Max(); ++i)
        {
            RandomNumbers->Add(FGuid::NewGuid());
        }
    }
};
```
