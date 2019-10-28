FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ListChallengeServer.csproj", "ListChallengeServer/"]
RUN dotnet restore "ListChallengeServer/ListChallengeServer.csproj"
COPY . angularApp2/
WORKDIR "/src/ListChallengeServer"
RUN dotnet build "ListChallengeServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ListChallengeServer.csproj" -c Release -o /app


#Angular build
FROM node as nodebuilder

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH


# install and cache app dependencies
COPY ListChallengeSpa/package.json /usr/src/app/package.json
RUN npm install
RUN npm install -g @angular/cli@1.7.0 --unsafe

# add app

COPY ClientApp/. /usr/src/app

RUN npm run build

#End Angular build

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN mkdir -p /app/ListChallengeSpa/dist
COPY --from=nodebuilder /usr/src/app/dist/. /app/ListChallengeSpa/dist/
ENTRYPOINT ["dotnet", "angularApp2.dll"]