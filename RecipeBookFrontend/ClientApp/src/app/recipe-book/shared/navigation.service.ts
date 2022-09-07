import { Injectable } from '@angular/core'
import { Location } from '@angular/common'
import { Router, NavigationEnd, ActivatedRoute, NavigationStart, RoutesRecognized, RouteConfigLoadStart, NavigationError } from '@angular/router'

@Injectable()
export class NavigationService {
    private history: string[] = []

    constructor(private router: Router, private location: Location, private route: ActivatedRoute) {
        this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd) {
                console.log(event.urlAfterRedirects);
                this.history.push(event.urlAfterRedirects)
            }
            if (event instanceof NavigationStart) {
                console.log('Navigation Start')
            }
        })
    }

    back(): void {
        this.history.pop()
        if (this.history.length > 0) {
            this.location.back()
        } else {
            this.router.navigateByUrl('/')
        }
    }
}