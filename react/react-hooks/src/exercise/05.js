// useRef and useEffect: DOM interaction
// http://localhost:3000/isolated/exercise/05.js

import * as React from 'react'
// eslint-disable-next-line no-unused-vars
import VanillaTilt from 'vanilla-tilt'

function Tilt({children}) {
  // 🐨 create a ref here with React.useRef()
  const tiltRef = React.useRef()

  // 🐨 add a `React.useEffect` callback here and use VanillaTilt to make your
  // div look fancy.
  React.useEffect(() => {
    const tiltNode = tiltRef.current
    VanillaTilt.init(tiltNode, {
      max: 25,
      speed: 400,
      glare: true,
      'max-glare': 0.5,
    })

    // 💰 Don't forget to return a cleanup function. VanillaTilt.init will add an
    // object to your DOM node to cleanup:
    return () => tiltNode.vanillaTilt.destroy()
  }, [])

  // 🐨 add the `ref` prop to the `tilt-root` div here:
  return (
    <div ref={tiltRef} className="tilt-root">
      <div className="tilt-child">{children}</div>
    </div>
  )
}

function App() {
  return (
    <Tilt>
      <div className="totally-centered">vanilla-tilt.js</div>
    </Tilt>
  )
}

export default App
