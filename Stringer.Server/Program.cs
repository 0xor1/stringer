using Common.Server;
using Stringer.Db;
using Stringer.Eps;
using Stringer.I18n;

Server.Run<StringerDb>(args, S.Inst, StringerEps.Eps);
