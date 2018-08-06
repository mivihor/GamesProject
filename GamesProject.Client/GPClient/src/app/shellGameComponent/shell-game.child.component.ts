import { Component, Input, OnInit, Output, EventEmitter } from "@angular/core";
import { UserService } from "../user.service";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
    selector: 'shell-child',
    template: `<div class="userInfoFrame">
                    <div class="userInfoFrameHeader">
                    User: {{userLogin}}<br>
                    Score: {{userScore}}
                    </div>
                        </div>`,
    styleUrls: ['./shell-game.child.component.css']
})
export class ShellGameChildComponent implements OnInit{
    
userLogin:string = sessionStorage.getItem("userLogin");
//userScore: number;

constructor(private userService: UserService) {}


@Input() userScore:number;
@Output() onChange: EventEmitter<number> = new EventEmitter<number>();

ngOnInit():void{    
this.userService.getUserScore(this.userLogin).subscribe((score:any) =>
    {
        this.userScore = score.userScore;
        this.onLoad(this.userScore);
    },
    (err:HttpErrorResponse)=>{
        console.log(err.message);
    });
}
onLoad(score:number):void{
    this.onChange.emit(score);
}
}