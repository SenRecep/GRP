const clientInfo = {
    BaseUrl: "http://185.122.202.87:8263/",
    GrantType: {
        ClientCredential: "client_credentials",
        ResourceOwnerPasswordCredential: "password",
        RefreshTokenCredential: "refresh_token"
    },
    WebClient: {
        ClientId: "WebClient_CC",
        ClientSecret: "webclient_client_secret"
    },

    WebClientForUser: {
        ClientId: "WebClient_ROP",
        ClientSecret: "webclient_client_secret"
    }
}

// module.exports = clientInfo;
export default clientInfo;
