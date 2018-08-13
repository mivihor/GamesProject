export class UserLog{
    dayTime:number;
    gameRes:boolean;
    win:number;
    winShell:number;
    constructor(t:number, gs:boolean, w:number, ws:number){
        this.dayTime = t;
        this.gameRes=gs;
        this.win = w;
        this.winShell = ws;
    }
}