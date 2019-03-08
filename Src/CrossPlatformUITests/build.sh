cd..
PROJECTNAME=CrossPlatformUITests
PROJECT="CrossPlatformUITests.csproj"
PROJECTPATH=./${PROJECT}
NUNITRUNNER_PATH=./packages/NUnit.Runners.Net4.2.6.4/tools/nunit-console.exe
UITESTSDLL_PATH=./CrossPlatformUITests/bin/Debug/CrossPlatformUITests.dll

build(){
echo "Build UITests Project ..."

msbuild ${PROJECTPATH} /target:Build /p:Configuration=Debug
}

runTests(){
cd ..
echo "Running UI Tests Project ..."

mono ${NUNITRUNNER_PATH} ${UITESTSDLL_PATH}
}

build
runTests
