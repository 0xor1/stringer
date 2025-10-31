using Common.Client;
using Stringer.Api;
using Stringer.Client;
using Stringer.I18n;

await Client.Run<App, IApi>(args, S.Inst, (client) => new Api(client));
