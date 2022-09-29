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
        console.log(this.history)
        if (this.history.length > 0) {
            this.router.navigateByUrl(this.history[this.history.length - 1])
        } else {
            this.router.navigateByUrl('/')
        }
    }
}