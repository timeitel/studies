// Simple Data-fetching
// http://localhost:3000/isolated/exercise/01.js

import * as React from 'react'
// 🐨 you'll also need to get the fetchPokemon function from ../pokemon:
import {PokemonDataView, fetchPokemon, PokemonErrorBoundary} from '../pokemon'

// fetchPokemon(pokemonName).then(handleSuccess, handleFailure)

let pokemon
let pokemonError
// We don't need the app to be mounted to know that we want to fetch the pokemon
// named "pikachu" so we can go ahead and do that right here.
// 🐨 assign a pokemonPromise variable to a call to fetchPokemon('pikachu')
const pokemonPromise = fetchPokemon('pikachu').then(
  resolvedValue => (pokemon = resolvedValue),
  error => (pokemonError = error),
)

function PokemonInfo() {
  // 🐨 if there's no pokemon yet, then throw the pokemonPromise
  // � (no, for real. Like: `throw pokemonPromise`)
  if (pokemonError) throw pokemonError
  if (!pokemon) throw pokemonPromise

  // if the code gets it this far, then the pokemon variable is defined and
  // rendering can continue!
  return (
    <div>
      <div className="pokemon-info__img-wrapper">
        <img src={pokemon.image} alt={pokemon.name} />
      </div>
      <PokemonDataView pokemon={pokemon} />
    </div>
  )
}

function App() {
  return (
    <div className="pokemon-info-app">
      <div className="pokemon-info">
        <PokemonErrorBoundary>
          <React.Suspense fallback="loading">
            <PokemonInfo />
          </React.Suspense>
        </PokemonErrorBoundary>
      </div>
    </div>
  )
}

export default App
