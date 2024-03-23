import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  public isLogin: boolean | undefined;
  constructor(private authService: AuthService, private route: Router) { }
  ngOnInit(): void {
    this.authService.tokenSubject.subscribe(resp => {
      this.isLogin = resp;
    })
  }

  logout() {
    this.authService.clearlocalStorage()
    this.route.navigate(['/login']);
  }

}
