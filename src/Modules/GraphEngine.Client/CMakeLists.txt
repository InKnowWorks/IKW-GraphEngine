CMAKE_MINIMUM_REQUIRED(VERSION 3.5.0)
PROJECT(GraphEngine.Client)

ADD_DOTNET(Trinity.Client/Trinity.Client.csproj
    PACKAGE GraphEngine.Client
    VERSION ${TRINITY_VERSION}
    DEPENDS GraphEngine.Core)

# TODO unit test
