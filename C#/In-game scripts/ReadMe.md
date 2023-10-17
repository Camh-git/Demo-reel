# Scripts for space engineers
A collection of miscellaneous scripts created using in-game programing api for the game space engineers.
This mostly exists to demonstrate working with this kind of API, some collision detection and sequencing.
The code for each project can be found in /project name/Program.cs

## Current scripts
<ul>
  <li>
    <h4>Drunk fire</h4>
    <p>A program to help custom missiles evade interception by confusing predictive tracking.</p>
    <strong>(redundant due to AI features added in update 1.203)</strong>
  </li>
  <li>
    <h4>Large hanger door controller</h4>
    <p>Sequence controler for oppening large hinge,piston and hangerdoor actuated custom doors for drydock style large ship hangers.</p>
  </li>
  <li>
    <h4>Ramp controller</h4>
    <p>Sequence controler for a custom multi-segment boarding ramp, operable via toggle.</p>
  </li>
  <li>
    <h4>Alert control system</h4>
    <p>Allows the user to select 1 of 6 alert levels and manage alert settings, alerts can activate lights, sirens, power systems, locks and info pannels.</p>
    <p>Alert levels are: black(abandon ship), red(combat), yellow(hazard), blue(caution), green(all clear), final(self destruct) and none.</p>
    <strong>Currently undergoing refactor to better support subgrids and multiple screen sizes</strong>
  </li>
  <li>
    <h4>Hanger control system</h4>
    <p>Controls the full cycling process of a single hanger aboard a ship, can opperate with open/close commands or a simple toggle</p>
  </li>
  <li>
    <h4>Airlock control system</h4>
    <p>Controls the cycling process of all tagged airlocks aboard a ship, can opperate with open/close commands or a simple toggle.</p>
  </li>
</ul>

## Notes
some methods of opperation may be odd due to in-game restrictions, eg: waiting is handled by setting the
block to re-run every X amount of milliseconds and counting the runs until a target is reached, this is done
because the in-game system does not allow the use of thread.sleep or similar to prevent cheating.
