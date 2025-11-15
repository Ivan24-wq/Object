namespace StressTest;
public enum Material{
    StainlessSteel, 
    Aluminium, 
    ReinforcedConcrete, 
    Composit, 
    Titanium
}

public enum CrossSelection{
    IBeam, 
    Box, 
    ZShaped, 
    CShaped
}

public enum TestResult
{
    Pass,
    Fail
}

public struct TestCaseResult
{
    public TestResult Result;
    public string ReasonForFailure;
}