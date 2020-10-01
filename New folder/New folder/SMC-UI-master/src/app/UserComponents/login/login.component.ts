import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/authentication.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router : Router , private authService : AuthenticationService) { }

  ngOnInit(): void {
    
  }

  onSubmit(event)
  {
    const target = event.target
    const username = target.querySelector('#username').value;
    const password = target.querySelector('#password').value;
    console.log(username,password)
   this.authService.login(username , password).pipe(first())
   .subscribe(
    data => {    
      AuthenticationService.isLogged = true;
      this.router.navigate(['/Dashboard']);
    },
    error => {
        console.log(error);

    });
  }
}
