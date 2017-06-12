import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

export class NesGame {
    name: string;
    numberOfPlayers: string;
    type: string;
    save: string;
    simultaneousTurn: string;
    numberOfScrews: string;
    instructions: string;
    box: string;
    markingsEtc: string;
    publisher: string;
    feature: string;

    public constructor(init?: Partial<NesGame>) {
        Object.assign(this, init);
    }
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    title = 'Nicole is the best girlfriend ever';

    constructor(private _httpService: Http) { }

    nesGames: NesGame[];

    ngOnInit() {
        this._httpService.get('/api/GoogleSheets').subscribe(games => {
            this.nesGames = this.mapToModel(games.json()) as NesGame[];
        });
    }

    private mapToModel(rawGames: Object[]): NesGame[] {
        let mappedNesGames: NesGame[];

        mappedNesGames = rawGames.map(game => {
            let typeGame: NesGame = game as NesGame;
            let x = new NesGame({
                name: typeGame.name,
                numberOfPlayers: typeGame.numberOfPlayers,
                type: typeGame.type,
                save: typeGame.save,
                simultaneousTurn: typeGame.simultaneousTurn,
                numberOfScrews: typeGame.numberOfScrews,
                instructions: typeGame.instructions,
                box: typeGame.box,
                markingsEtc: typeGame.markingsEtc,
                publisher: typeGame.publisher,
                feature: typeGame.feature
            });
            return x;
        });

        return mappedNesGames;
    }
}
