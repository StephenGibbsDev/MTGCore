import Oidc from 'oidc-client';

var mgr = new Oidc.UserManager({
    authority: 'https://localhost:5443',
    client_id: 'js',
    redirect_uri: 'https://localhost:44315/callback',
    response_type: 'id_token token',
    scope: 'openid profile api1',
    post_logout_redirect_uri: 'https://localhost:44315/',
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
})

Oidc.Log.logger = console;
Oidc.Log.level = Oidc.Log.INFO;

export default mgr;